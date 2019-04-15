// Copyright (c) 2011 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

// Called when the user clicks on the browser action.

chrome.browserAction.onClicked.addListener(function(tab) {
  // No tabs or host permissions needed!
	chrome.tabs.insertCSS({file:"content.css"});  
	chrome.tabs.executeScript({file: "jquery-3.3.1.min.js"});
	chrome.tabs.executeScript({file: "md5-proto.js"});
	chrome.tabs.executeScript({file: "content.js"});
});