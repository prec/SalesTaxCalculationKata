/// <reference types="aurelia-loader-webpack/src/webpack-hot-interface"/>
// we want font-awesome to load as soon as possible to show the fa-spinner
import { Aurelia } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import environment from './environment';
import {PLATFORM} from 'aurelia-pal';
import * as Bluebird from 'bluebird';
import 'whatwg-fetch';

// remove out if you don't want a Promise polyfill (remove also from webpack.config.js)
Bluebird.config({ warnings: { wForgottenReturn: false } });

export function configure(aurelia: Aurelia) {
  aurelia.use
    .standardConfiguration()
    .feature(PLATFORM.moduleName('resources/index'));

  // Uncomment the line below to enable animation.
  // aurelia.use.plugin(PLATFORM.moduleName('aurelia-animator-css'));
  // if the css animator is enabled, add swap-order="after" to all router-view elements

  // Anyone wanting to use HTMLImports to load views, will need to install the following plugin.
  // aurelia.use.plugin(PLATFORM.moduleName('aurelia-html-import-template-loader'));

  if (environment.debug) {
    aurelia.use.developmentLogging();
  }

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
  }

  const container = aurelia.container;
  const httpClient = new HttpClient();
  httpClient.configure(config => {
    config
      .useStandardConfiguration()
      .withBaseUrl("api/")
      .withDefaults({
        credentials: "same-origin",
        headers: {
          "Accept": "application/json",
          "X-Requested-With": "Fetch"
        }
      });
  });
  container.registerInstance(HttpClient, httpClient);

  return aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
