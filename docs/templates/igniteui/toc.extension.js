// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * This method will be called at the start of exports.transform in toc.html.js
 */
exports.preTransform = function (model) {
    model._disableSideFilter = false;

    model._isLangEn = true;
    model._isLangJa = false;
    model._isLangKr = false;
    if (model.items[0]._language) {
      if (model.items[0]._language === "ja") {
        model._isLangJa = true;
        model._isLangEn = model._isLangKr = false;
      } else if (model.items[0]._language === "kr") {
        model._isLangKr = true;
        model._isLangEn = model._isLangJa = false;
      }
    }

    return model;
};

/**
 * This method will be called at the end of exports.transform in toc.html.js
 */
exports.postTransform = function (model) {
    return model;
};