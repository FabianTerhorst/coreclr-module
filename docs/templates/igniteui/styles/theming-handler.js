(function () {
    $(document).ready(function() {
        var sampleIframes = document.querySelectorAll("iframe");
        var isIE = !(window.ActiveXObject) && "ActiveXObject" in window;
        if ($(".themes-container").length !== 0 && sampleIframes.length !== 0 &&
            (!isDvPage() || !isIE)) {
            $(".themes-container").css('display', 'inline-flex');
        } else {
            return;
        }

        if (isIE) {
            $('.theme-select-wrapper').css('display', 'inline-flex');
            $('.theme-select-wrapper').removeClass('theme-wrapper-hide');
            var currentTheme = window.sessionStorage.getItem("theme");
            if (currentTheme) {
                var item = $(".theme-item").filter("[data-theme=" + currentTheme + "]")[0];
                handleThemeSelection(currentTheme, item);
            }
           

            $(".theme-item").on("click", function (e) {
                if (e.currentTarget.lastElementChild.tagName === "svg") {
                return;
                
                }
                var currentTheme = window.sessionStorage.getItem("theme");
                var newTheme = this.getAttribute("data-theme");
                if (currentTheme !== newTheme) {
                handleThemeSelection(newTheme, this);
                }
            })
        } else {
            $('.theme-widget-wrapper').removeClass('theme-wrapper-hide');
            var themingWidget = $('igniteui-theming-widget');
            if (themingWidget) {
                themingWidget.on('themeChange', function(event) {
                    window.sessionStorage.setItem('themeStyle', event.originalEvent.detail);
                    sampleIframes.forEach(function (element) {
                        if (!$(element).hasClass("no-theming") && (!$(element).hasClass("lazyload") || $(element).hasClass("lazyloaded"))) {
                            var src = !!element.src ? element.src : element.dataset.src;
                            var data = {
                                themeStyle: event.originalEvent.detail,
                                origin: window.location.origin,
                                themeName: themingWidget[0].theme.globalTheme
                            };
                            element.contentWindow.postMessage(data, src);
                        }
                    });
                });
            }
        }
    });

    function handleThemeSelection(theme, item) {
        if (theme) {
            if (isDvPage()) {
            // reset the theme to the default one
                theme = "default-theme";
                window.sessionStorage.setItem('theme', theme);
            }
            if (item) {
                postMessage(theme);
            }
            var visibleItems = $(".theme-item:lt(2)");
            var visibleThemes = [];
            var themeItem = item ? item : $(".theme-item").filter("[data-theme=" + theme + "]")[0];
        
            $.each(visibleItems, function(i, el) {
                visibleThemes.push(el.getAttribute("data-theme"));
            })
        
            if (visibleThemes.indexOf(theme) !== -1) {
                selectTheme(themeItem);
            } else {
                closeContainer();
            }
        }
        
        function postMessage(theme) {
            var targetOrigin = document.body.getAttribute("data-demos-base-url"); 
            var data = {origin: window.location.origin};
            window.sessionStorage.setItem('theme', theme);
            $("iframe").filter(function ( index ) {
                return !this.classList.contains("lazyload")
            }).each( function(i, e)  {
                if(e.classList.contains("no-theming")){
                    data["theme"] = "default-theme";
                }else{
                    data["theme"] = theme;
                }
                var iframeWindow = e.contentWindow;
                iframeWindow.postMessage(data, targetOrigin);
            });
        }
        
        function selectTheme(el) {
            var oldSelection = document.getElementsByClassName("theme-item--active");
            if (oldSelection.length > 0) {
                oldSelection[0].classList.remove("theme-item--active");
            }
            el.classList.add("theme-item--active");
        }
    }
}());

