(function () {
    var stkbButtonClass = "stackblitz-btn";
    var cbsButtonClass = "codesandbox-btn";
    var stackBlitzApiUrl = "https://run.stackblitz.com/api/angular/v1";
    var codesandboxApiUrl = "https://codesandbox.io/api/v1/sandboxes/define";

    var buttonIframeIdAttrName = "data-iframe-id";
    var buttonSampleSourceAttrName = "data-sample-src";
    var buttonDemosUrlAttrName = "data-demos-base-url";


    var sharedFileName = "shared.json";
    var assetsFolder = "/assets/";
    var demoFilesFolderUrlPath = assetsFolder + "samples/";
    var demoFilesCSSSupportFolderUrlPath = demoFilesFolderUrlPath + "css-support/";

    var isIE = navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0;
    var isEdge = navigator.userAgent.indexOf('Edge') !== -1;

    var assetsRegex = new RegExp("\/?assets\/", "g");
    var sampleFilesContentByUrl = {};
    var isButtonClickInProgress = false;
    var isLocalhost = Boolean(
        window.location.hostname === 'localhost' ||
        // [::1] is the IPv6 localhost address.
        window.location.hostname === '[::1]' ||
        // 127.0.0.1/8 is considered localhost for IPv4.
        window.location.hostname.match(
            /^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/
        ));

    var demosTimeStamp;
    var sharedFileContent;
    var init = function () {
        var projectButtons;
        if(isIE || isEdge) {
            projectButtons = $("." + stkbButtonClass);
            $("." + cbsButtonClass).remove();
        } else {
            projectButtons = $("." + stkbButtonClass + ", ." + cbsButtonClass);
        }

        if (projectButtons.length > 0) {
            if (!isLocalhost) {
                $.each(projectButtons, function (index, element) {
                    $(element).removeAttr("disabled");
                    $(element).on("click", onGithubProjectButtonClicked);
                });
            } else {
                var demosBaseUrls = new Set();

                $.each(projectButtons, function (index, element) {
                    demosBaseUrls.add($(element).attr(buttonDemosUrlAttrName))
                });

                var hasMultipleUrls = demosBaseUrls.size > 1;

                if (hasMultipleUrls) {
                    demosBaseUrls.forEach(function (url) {
                        var currentDemoUrlButtons = $(projectButtons).filter(function (index, element) {
                            return $(element).attr(buttonDemosUrlAttrName) === url;
                        });
                        generateLiveEditingApp(url, currentDemoUrlButtons)
                    });

                } else {
                    demosBaseUrl = $(projectButtons[0]).attr(buttonDemosUrlAttrName);
                    generateLiveEditingApp(demosBaseUrl, projectButtons)
                }
            }
        }
    }

    var getGitHubSampleUrl = function (editor, sampleUrl, branch) {
        if (editor === "stackblitz") return "https://stackblitz.com/github/IgniteUI/igniteui-live-editing-samples/tree/" + branch + "/" + sampleUrl;
        return "https://codesandbox.io/s/github/IgniteUI/igniteui-live-editing-samples/tree/" + branch + "/" + sampleUrl + "?fontsize=14&hidenavigation=1&theme=dark&view=preview"
    }

    var getGitHubSampleUrlFromButton = function ($button, demosBaseUrl) {
        var sampleSrc = "";
        var buttonIframeId = $button.attr(buttonIframeIdAttrName);
        if (buttonIframeId) {
            var iframe = $("#" + buttonIframeId);
            if (iframe.attr("src")) {
                sampleSrc = iframe.attr("src");
            } else {
                sampleSrc = iframe.attr("data-src");
            }
        } else {
            sampleSrc = $button.attr(buttonSampleSourceAttrName);
        }
        // Get sample application base path
        const projectPath = demosBaseUrl.substring(demosBaseUrl.lastIndexOf("/") + 1)
        var demoPath = sampleSrc.replace(demosBaseUrl + "/", projectPath + (isIE || isEdge ? "/css-support/" : "/"));
        return demoPath;
    }

    var onGithubProjectButtonClicked = function (event) {
        if (isButtonClickInProgress) {
            return;
        }
        isButtonClickInProgress = true;
        var $button = $(this);
        var sampleFileUrl = getGitHubSampleUrlFromButton($button, $(this).attr(buttonDemosUrlAttrName));
        var editor = event.target.classList.value === stkbButtonClass ? "stackblitz" :
            "codesandbox";
        var branch = $(this).attr(buttonDemosUrlAttrName).indexOf("staging.infragistics.com") !== -1 ? "vNext" : "master";
        window.open(getGitHubSampleUrl(editor, sampleFileUrl, branch), '_blank');
        isButtonClickInProgress = false;
    }

    var generateLiveEditingApp = function (demosBaseUrl, $buttons) {
        var samplesFilesUrls = [];

        $.each($buttons, function (index, element) {

            var $button = $(element);
            var sampleFileUrl = getSampleUrlFromButton($button, demosBaseUrl);

            if (samplesFilesUrls.indexOf(sampleFileUrl) === -1) {
                samplesFilesUrls.push(sampleFileUrl);
            }

            $button.on("click", onProjectButtonClicked);
        });

        var metaFileUrl = demosBaseUrl + getDemoFilesFolderUrlPath() + "meta.json";
        // prevent caching 
        metaFileUrl += "?t=" + new Date().getTime();

        $.get(metaFileUrl).done(function (response) {
            demosTimeStamp = response.generationTimeStamp;
            getFiles($buttons, demosBaseUrl, samplesFilesUrls, demosTimeStamp);
        });
    }

    var getFiles = function ($buttons, demosBaseUrl, samplesFilesUrls, demosTimeStamp) {

        var sharedFileUrl = demosBaseUrl + getDemoFilesFolderUrlPath() + sharedFileName;
        sharedFileUrl = addTimeStamp(sharedFileUrl, demosTimeStamp);

        var requests = [$.get(sharedFileUrl)];

        $.each(samplesFilesUrls, function (index, url) {
            url = addTimeStamp(url, demosTimeStamp);
            var ajax = $.get(url);
            requests.push(ajax);
        });

        $.when.apply($, requests).done(function () {
            replaceRelativeAssetsUrls(arguments[0][0].files, demosBaseUrl);
            sharedFileContent = arguments[0][0];

            for (var i = 1; i < arguments.length; i++) {
                replaceRelativeAssetsUrls(arguments[i][0].sampleFiles, demosBaseUrl);
                var url = this[i].url;
                url = removeQueryString(url);
                sampleFilesContentByUrl[url] = arguments[i][0];
            }

            $buttons.removeAttr("disabled");
        });
    }

    var addTimeStamp = function (url, demosTimeStamp) {
        if (!demosTimeStamp) {
            throw Error("Timestamp cannot be added.");
        }

        url += "?t=" + demosTimeStamp;
        return url;
    }

    var removeQueryString = function (url) {
        var questionMarkIndex = url.indexOf('?');
        if (questionMarkIndex !== -1) {
            url = url.substring(0, questionMarkIndex);
        }

        return url;
    }

    var getDemoFilesFolderUrlPath = function () {
        if (isIE || isEdge) {
            return demoFilesCSSSupportFolderUrlPath;
        }

        return demoFilesFolderUrlPath;
    }

    var getSampleUrlFromButton = function ($button, demosBaseUrl) {
        var sampleSrc = "";
        var buttonIframeId = $button.attr(buttonIframeIdAttrName);
        if (buttonIframeId) {
            var iframe = $("#" + buttonIframeId);
            if (iframe.attr("src")) {
                sampleSrc = iframe.attr("src");
            } else {
                sampleSrc = iframe.attr("data-src");
            }
        } else {
            sampleSrc = $button.attr(buttonSampleSourceAttrName);
        }

        var demoPath = sampleSrc.replace(demosBaseUrl + "/", "");
        demoPath = demoPath.replace("/", "--");
        var demoFileUrl = demosBaseUrl +
            getDemoFilesFolderUrlPath().substring(0, getDemoFilesFolderUrlPath().length - 1) +
            "/" + demoPath + ".json";
        return demoFileUrl;
    }

    var onProjectButtonClicked = function (event) {
        if (isButtonClickInProgress) {
            return;
        }

        isButtonClickInProgress = true;
        var $button = $(this);
        var sampleFileUrl = getSampleUrlFromButton($button, $(this).attr(buttonDemosUrlAttrName));
        var sampleContent = sampleFilesContentByUrl[sampleFileUrl];
        var formData = {
            dependencies: sampleContent.sampleDependencies,
            files: sharedFileContent.files.concat(sampleContent.sampleFiles),
            devDependencies: sharedFileContent.devDependencies
        }
        var form = $button.hasClass(stkbButtonClass) ? createStackblitzForm(formData) :
                                                                      createCodesandboxForm(formData);
        form.appendTo($("body"));
        form.submit();
        form.remove();
        isButtonClickInProgress = false;
    }

    var replaceRelativeAssetsUrls = function (files, demosBaseUrl) {
        var assetsUrl = demosBaseUrl + assetsFolder;
        for (var i = 0; i < files.length; i++) {
            if (files[i].hasRelativeAssetsUrls) {
                files[i].content = files[i].content.replace(assetsRegex, assetsUrl);
            }
        }
    }

    /*  a sample forms object -
        {
            description: `The greatest sample`,
            files: [{
                path: `src/index.html`,
                content: `<h1>Hello world!</h1>`
            }],
            dependencies: `"@angular/animations": "^5.2.0",
                "@angular/common": "^5.2.0"`,
            tags: ["tagA", "tagB", "tagC"]
        }
    */

    function compress(input) {
        return window.LZString.compressToBase64(input)
            .replace(/\+/g, "-") // Convert '+' to '-'
            .replace(/\//g, "_") // Convert '/' to '_'
            .replace(/=+$/, ""); // Remove ending '='
    }

    var createStackblitzForm = function (data) {
        var form = $("<form />", {
            method: "POST",
            action: stackBlitzApiUrl,
            target: "_blank",
            style: "display: none;"
        });

        // files
        for (var i = 0; i < data.files.length; i++) {
            var fileInput = $("<input />", {
                type: "hidden",
                name: "files[" + data.files[i].path + "]",
                value: data.files[i].content
            });

            fileInput.appendTo(form);
        }

        // tags
        if (data.tags) {
            for (var i = 0; i < data.tags.length; i++) {
                var tagInput = $("<input />", {
                    type: "hidden",
                    name: "tags[" + i + "]",
                    value: data.tags[i]
                });

                tagInput.appendTo(tagInput);
            }
        }

        // description
        if (data.description) {
            var descriptionInput = $("<input />", {
                type: "hidden",
                name: "description",
                value: data.description
            });

            descriptionInput.appendTo(form);
        }

        // dependencies
        var dependenciesInput = $("<input />", {
            type: "hidden",
            name: "dependencies",
            value: data.dependencies
        });

        dependenciesInput.appendTo(form);
        return form;
    }

    var createCodesandboxForm = function (data) {
        const fileToSandbox = {
            files: {
                "sandbox.config.json": {
                    "content": {
                        "infiniteLoopProtection": false,
                        "hardReloadOnChange": false,
                        "view": "browser",
                        "template": "angular-cli"
                    }
                },
                "package.json": {
                    "content": {
                        "dependencies": JSON.parse(data.dependencies),
                        "devDependencies": data.devDependencies
                    }
                }
            }
        };
        const f = data.files.forEach( function (f) {
            fileToSandbox.files[f["path"].replace("./", "")] = {
                content: f["content"]
            }
        });

        var form = $("<form />", {
            method: "POST",
            action: codesandboxApiUrl,
            target: "_blank",
            style: "display: none;"
        });

        var fileInput = $("<input />", {
            type: "hidden",
            name: "parameters",
            value: compress(JSON.stringify(fileToSandbox))
        });

        fileInput.appendTo(form)
        return form;
    }

    $(document).ready(function () {
        init();
    });
}());