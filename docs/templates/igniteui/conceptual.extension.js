// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * This method will be called at the start of exports.transform in conceptual.html.primary.js
 */
exports.preTransform = function(model) {
    model._appTitle = 'Ignite UI for Angular';
    model._disableContribution = true;
    return model;
};

/**
 * This method will be called at the end of exports.transform in conceptual.html.primary.js
 */
exports.postTransform = function(model) {
    return model;
};
