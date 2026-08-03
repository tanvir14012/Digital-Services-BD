// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(function ($, bootstrap) {
    "use strict";

    function copyAttributeValue(element, sourceName, targetName) {
        const sourceValue = element.getAttribute(sourceName);
        if (sourceValue && !element.hasAttribute(targetName)) {
            element.setAttribute(targetName, sourceValue);
        }
    }

    function applyBootstrap5DataAttributeCompatibility() {
        document.querySelectorAll("[data-toggle], [data-target], [data-dismiss], [data-slide], [data-slide-to], [data-placement]")
            .forEach((element) => {
                copyAttributeValue(element, "data-toggle", "data-bs-toggle");
                copyAttributeValue(element, "data-target", "data-bs-target");
                copyAttributeValue(element, "data-dismiss", "data-bs-dismiss");
                copyAttributeValue(element, "data-slide", "data-bs-slide");
                copyAttributeValue(element, "data-slide-to", "data-bs-slide-to");
                copyAttributeValue(element, "data-placement", "data-bs-placement");
            });
    }

    function registerJQueryBootstrapPluginCompat() {
        if (!$ || !bootstrap) {
            return;
        }

        if (!$.fn.tooltip && bootstrap.Tooltip) {
            $.fn.tooltip = function (options) {
                return this.each(function () {
                    bootstrap.Tooltip.getOrCreateInstance(this, options || {});
                });
            };
        }

        if (!$.fn.popover && bootstrap.Popover) {
            $.fn.popover = function (options) {
                return this.each(function () {
                    bootstrap.Popover.getOrCreateInstance(this, options || {});
                });
            };
        }
    }

    $(function () {
        applyBootstrap5DataAttributeCompatibility();
        registerJQueryBootstrapPluginCompat();
    });
})(window.jQuery, window.bootstrap);
