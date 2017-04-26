import axios from 'axios';
import $ from 'jquery';

import { mapState, mapMutations } from 'vuex';

export default {

    name: 'navmenu',
    data() {
        return {
            //菜单切换显示
            show: '-1',
            //菜单编辑
            edit: false,

            //主菜单编辑界面显示隐藏
            Menu: false,
            //子菜单编辑界面显示隐藏
            SubMenu: false,
            //主菜单id
            OneMenuId: 0,

            CategoryAdd: false,
            // 主菜单数据
            cOne: {},
            //子菜单数据
            subCategory: null,

            FoodAdd: false,
            CookbookAdd: false,
            PackageAdd: false,
            formLabelWidth: '120px',

            tableData: {


            },
        }
    },
    computed: {
        ...mapState(['categorys'])
    },
    props: ['collapsed'],
    //菜单数据加载 
    created: function () {
        this.getMenu();
    },
    methods: {
        // 获取Menu数据
        getMenu() {
            $.ajax({
                type: "GET",
                url: '/Menu/IndexAsync',
                success: (data) => {
                    this.setCategorys(data);
                },
                error: function () {
                    alert("There was error uploading files!");
                }
            });
        },
        ...mapMutations({
            setCategorys: 'categorys'
        }),
        onSubmit() {
            console.log('submit!');
        },
        handleopen() {
            //console.log('handleopen');
        },
        handleclose() {
            //console.log('handleclose');
        },
        handleselect: function (a, b) { },
        //退出登录
        logout: function () {
            var _this = this;
            this.$confirm('确认退出吗?', '提示', {
            }).then(() => {
                console.log('确定')
                window.location.href = "/logout"
            }).catch(() => {
                console.log('取消')
            });
            //this.$confirm('确认退出吗?', '提示', {
            //}).then(() => {
            //    console.log('确定')
            //    window.location.href = "/logout"
            //}).catch(() => {
            //    console.log('取消')
            //});
        },
        CategoryCountAdd() {
            this.Categorycount.push(
                {
                    categoryId: 0,
                    icon: '1',
                    name: '1',
                    url: '1',
                    file: null
                })
        },
        //一级菜单修改
        cOneEdit(index) {
            this.cOne = this.categorys[index];
            console.log(this.cOne);
            this.Menu = true;
        },
        // 删除一级菜单
        cOneDelete(id) {
            this.$confirm('确认删除吗?', '提示', {
            }).then(() => {
                console.log('确定')
                var url = '/Category/CategoryOneDeleteAsync/?id=' + id;
                $.ajax({
                    type: "GET",
                    url: url,
                    success: (data) => {
                        this.setCategorys(data);
                    },
                    error: function () {
                        alert("There was error uploading files!");
                    }
                });
            }).catch(() => {
                console.log('取消')
            });

        },
        //二级菜单编辑
        SubEdit(index,subIdnex) {
            this.subCategory = this.categorys[index].subCategory[subIdnex];
            this.SubMenu = true;
        },
        // 删除二级菜单
        SubCategoryDelete(id) {
            this.$confirm('确认删除吗?', '提示', {
            }).then(() => {
                console.log('确定')
                var url = '/Category/SubCategoryDeleteAsync/?id=' + id;
                $.ajax({
                    type: "GET",
                    url: url,
                    success: (data) => {
                        this.setCategorys(data);
                    },
                    error: function () {
                        alert("There was error uploading files!");
                    }
                });
            }).catch(() => {
                console.log('取消')
            });

        },
        // 新曾菜单编辑 清楚数据
        MenuInit(OneMenuId) {
            this.cOne = { icon: '', name: '', url: '', file: null, imgUrl: '' };
            this.Categorycount = [];
            this.OneMenuId = OneMenuId;
        },
        toFood(index) {
            console.log(index);
            this.$router.push({ name: 'food', params: { index: index} });
        }
    },
}