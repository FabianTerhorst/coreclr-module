// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.

var common = require('./common.js');
var extension = require('./conceptual.extension.js')

exports.transform = function (model) {
  if (extension && extension.preTransform) {
    model = extension.preTransform(model);
  }

  model._disableToc = model._disableToc || !model._tocPath || (model._navPath === model._tocPath);
  model.docurl = model.docurl || common.getImproveTheDocHref(model, model._gitContribute, model._gitUrlPattern);

  if (extension && extension.postTransform) {
    model = extension.postTransform(model);
  }
  
  // We support English (default), Japanese and Korean. 
  model._isLangEn = true;
  model._isLangJa = false;
  model._isLangKr = false;
  model._appLang = "en";
  if (model._language) {
    if (model._language === "ja") {
      model._isLangJa = true;
      model._isLangEn = model._isLangKr = false;
      model._appLang = "ja";
    } else if (model._language === "kr") {
      model._isLangKr = true;
      model._isLangEn = model._isLangJa = false;
      model._appLang = "ko";
    }
  }

  return model;
}