import { createApp } from 'vue'
import App from './App.vue'
import router from "./router.js"
import store from "./store.js"
import appHeader from "@/components/Shared/appHeader"
//import vuetify from './vuetify'
import "@/assets/style.css"

import appBookmarkList from "@/components/Shared/appBookMarkList/bookmark"
import kullanici from "@/components/Shared/appBookMarkList/bookmark"

var Vue = require('vue')

const app = createApp(App);
app.component("AppHeader", appHeader);
app.component("appBookmarkList", appBookmarkList)
app.component("appBookmarkList2", kullanici)
//app.use(vuetify);
app.use(require('vue-cookies'))
app.use(store);
app.use(router);
app.mount('#app')




