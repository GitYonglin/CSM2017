import Vue from 'vue';
import VueRouter from 'vue-router';
import ElementUI from 'element-ui';

import store from './components/store/store';
var Food = require('./components/food/food.vue.html');

Vue.use(VueRouter);
Vue.use(ElementUI)


const routes = [
    { path: '/',name:'/', component: require('./components/home/home.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    { path: '/food', name:'food', component: Food},
    { path: 'main', component: require('./components/food/main/main.vue.html') },
    { path: '/food/edit', name:'edit', component: require('./components/food/edit/edit.vue.html') },
    { path: '**', component: require('./components/home/home.vue.html') }
];

new Vue({
    el: '#app-root',
    store,
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
