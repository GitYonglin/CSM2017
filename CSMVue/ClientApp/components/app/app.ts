//import Vue from 'vue';
//import { Component } from 'av-ts';

//@Component({
//    components: {
//        MenuComponent: require('../navmenu/navmenu.vue.html')
//    }
//})
//export default class AppComponent extends Vue {
//    collapsed: boolean = false;
//    sysName: string = '后台';
//    sysUserName: string = 'Peach';
//    sysUserAvatar: string = '';
//}

var MenuComponent = require('../navmenu/navmenu.vue.html')


export default {
    name: 'approot',
    data() {
        return {
            collapsed: false,
            sysName: '后台',
            sysUserName: 'Peach',
            sysUserAvatar: ''
        }
    },
    components: { MenuComponent }
}
