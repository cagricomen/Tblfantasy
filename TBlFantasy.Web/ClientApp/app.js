import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/root/app-root'
import { FontAwesomeIcon } from './icons'
import Notifications from 'vue-notification';
import PageHead from './components/shared/page-head'
import TBLText from './components/pages/input/text'


Vue.use(Notifications)
// Registration of global components
Vue.component('icon', FontAwesomeIcon)
Vue.component('page-head', PageHead)
Vue.component('tbl-text', TBLText)

Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
