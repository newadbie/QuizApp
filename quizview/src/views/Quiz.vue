<template>
    <div>
        <h2>{{ currentQuiz.title }}</h2>
    </div>
</template>

<script>
const axios = require('axios').default;

export default {
    data() {
        return {
            currentQuiz: null
        }
    },
    mounted() {
        var routeId = this.$route.params.id;
        if (isNaN(routeId))
        {
            alert("TODO INCORRECT ID"); // todo validate
        } 
        else {
            axios.get('https://localhost:5001/api/Quizzes/' + routeId).then(res => {
                this.currentQuiz = res.data;
            }).catch(ex => alert(ex))
        }
    }
}
</script>