// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.
var extension = require('./toc.extension.js')

const labels = {
  NEW: 'NEW',
  UPDATED: 'UPDATED',
  DEPRECATED: 'DEPRECATED label text example' // for the purposes of this example, if one day we decide to add a new label type 
}

exports.transform = function (model) {

  if (extension && extension.preTransform) {
    model = extension.preTransform(model);
  }

  transformItem(model, 1);
  if (model.items && model.items.length > 0) model.leaf = false;
  model.title = "Table of Content";
  model._disableToc = true;

  if (extension && extension.postTransform) {
    model = extension.postTransform(model);
  }

  return model;

  function transformItem(item, level) {
    // set to null incase mustache looks up
    item.topicHref = item.topicHref || null;
    item.tocHref = item.tocHref || null;
    item.name = item.name || null;

    item.level = level;
    if (item.items && item.items.length > 0) {
      var length = item.items.length;
      for (var i = 0; i < length; i++) {
        transformItem(item.items[i], level + 1);
      };
    } else {
      item.items = [];
      item.leaf = true;
    }

    if(item.new || item.updated) {
      item.withBadge = true;
      item.labelText = item.updated ? labels.UPDATED : labels.NEW;
      item.labelType = item.labelText ? item.labelText.toLowerCase() : null;
    } else if(item.items && item.items.length > 0) {
      const label = getLabelFromDirectChildren(item.items, item);
      item.labelText = typeof label !== "undefined" ? label : null;
      item.labelType = item.labelText !== null ? label.toLowerCase() : '';
      item.withBadge =  item.labelType !== '';
    } else {
      item.withBadge = null;
      item.newType = '';
    }
  }
}

  function getLabelFromDirectChildren(items, parent) {
    const childLabels = [];
    var labelToReturn;
     for (let index = 0; index < items.length; index++) {
       const item = items[index];
       var itemLabel;

       if(item.updated) {
         itemLabel = labels.UPDATED;
       } else if(item.new) {
         itemLabel = labels.NEW;
       } else {
         itemLabel = undefined;
       }

       if(typeof itemLabel !== "undefined") {
        childLabels.push(itemLabel);
       }
     }

     if(childLabels.length === 0 ) {
        labelToReturn = undefined;
     } else if(childLabels.indexOf(labels.UPDATED) !== -1) {
        labelToReturn = labels.UPDATED;
        parent.updated = true;
     } else {
        parent.new = true;
        labelToReturn = labels.NEW
     }

     return labelToReturn;
  }
