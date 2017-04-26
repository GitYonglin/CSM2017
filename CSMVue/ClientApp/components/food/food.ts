var FoodOperation = require('./template/operation.vue.html')

export default {
    name: 'food',
    beforeCreate: function () {
        if (this.$route.params.index == null) {
            this.$router.push({ name: '/' });
        }
    },
    data() {
        return {
        }
    },
    computed: {
        categorys() {
            return this.$store.state.categorys[0].subCategory[0];
        }
    },
    components: { FoodOperation }

}

