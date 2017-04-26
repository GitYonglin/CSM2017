import { mapState } from 'vuex'
import $ from 'jquery';


export default {
    beforeCreate: function () {
        if (this.$route.params.index == null) {
            this.$router.push({ name: '/' });
        }
    },
    data() {
        return {
            form: {
                name: '',
                desc: '',
                price: '',
                dose: 0,
                minDose: 0,
                inventory: 0,
                shelves: true,
                insertdate: '',
                categorys: [1, 2, 3],
                imgs: [
                    {
                        url: '',
                        title: '',
                        file: null,
                        describe: ''
                    }
                ]
            },
            img: {
                url: '',
                title: '',
                file: null,
                describe: ''
            },
            ck: [],
            ckv:[]
        }
    },
    computed: {
        ...mapState(['categorys'])
    },
    created: function () {
        console.log(this.categorys);
    },
    methods: {
        onSubmit() {
            console.log('submit!');
        },
        addImgs() {
            this.form.imgs.push(this.img);
        },
        srtTime(e) {
            this.form.insertdate = e;
            console.log(e);
        },
        fileUP(e, item) {
            // 获取图片文件
            var file = e.target.files[0];
            // 设置<img>src路径
            item.url = window.URL.createObjectURL(file);
        },
        ajaxSubmit() {
            var then = this;
            // 获取form对象内容 赋值给FormData对象
            var formData = new FormData($('#postForm')[0]);

            $.ajax({
                type: "POST",
                url: '/serverfood/edit',
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (message) {
                    console.log(message);
                    then.$router.push({ name: 'food', params: { index: then.$route.params.index } });
                },
                error: function () {
                    alert("There was error uploading files!");
                }
            });
        },
        check(e, id) {
            setTimeout( () => {
                //要执行的代码
                e.target.value = id;
            }, 20);
            console.log(e);
        }
    }
}

