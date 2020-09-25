<template>
    <div>
        <div class="wait" v-if="!isPageReady">
            {{ msg }}
        </div>
        <div class="PageReady" v-if="isPageReady">
            <div class="title">
                <h1
                v-if="isPageReady">{{ currentQuiz.title }}</h1>
            </div>
            <ShowQuestion v-for="question in currentQuiz.questions" 
                :key="question.id"
                :Question="question" />
        </div>
    </div>
</template>

<style lang="scss">
.PageReady {
    .title {
        width:100vw;
        h1 {
            color: #FFF;
            letter-spacing: 1.3px;
        }
        margin: 0;
        padding:2.5px;
        box-shadow:1px 5px 13px rgba(255,255,255,.1);
        border-bottom:1px solid #FFF;
    }
}

</style>

<script>
import ShowQuestion from '@/components/ShowQuestion.vue'
const axios = require('axios').default;

export default {
    data() {
        return {
            msg: "Waiting",
            isPageReady: false,
            currentQuiz: Object
        }
    },
    components: {
        ShowQuestion
    },
    watch: {
        currentQuiz(value) {
            console.log(value);
            if (value == null || (value.title == "" || value.title.Length == 0))
            {
                this.msg = "ERROR"; 
            }
            else 
            {
                this.isPageReady = !this.isPageReady;
            }
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