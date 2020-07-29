document.addEventListener('lazyloaded', function(e){
    $(e.target).parent().removeClass("loading");
    if (!window.igViewer.common.isDvPage() && !$(e.target).hasClass("no-theming")) {
        var isIE = !(window.ActiveXObject) && "ActiveXObject" in window;
        var targetOrigin = document.body.getAttribute("data-demos-base-url");
        var theme = window.sessionStorage.getItem(isIE ? "theme" : "themeStyle");
        var data = { origin: window.location.origin };
        data.themeName =  $('igniteui-theming-widget').length > 0 ?  $('igniteui-theming-widget')[0].theme.globalTheme: null;
        if (isIE) {
            data.theme = theme;
        } else {
            data.themeStyle = theme;
        }
        e.target.contentWindow.postMessage(data, targetOrigin);
    }
});