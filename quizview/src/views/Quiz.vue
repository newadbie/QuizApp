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
                :Question="question"
                />
            <button class="CheckAnswers" @click="CheckAnswers">
                Sprawdź odpowiedzi!
            </button>
        </div>
    </div>
</template>

<style lang="scss">
.PageReady {
    .title 
    {
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
    .CheckAnswers 
    {
        &:hover
        {
            cursor:pointer;
        }
        margin-top:30px;
        outline:none;
        padding:10px;
        background:dodgerblue;
        color:#FFF;
        text-shadow: 3px 3px 3px rgba(0,0,0,.3);
        font-size:1.6rem;
        border:none;
        border-radius:5%;
    }
}

</style>

<script>
import ShowQuestion from '@/components/ShowQuestion.vue'
const axios = require('axios').default;

export default {
    data() {
        return {
            msg: "Oczekiwanie",
            isPageReady: false,
            currentQuiz: Object,
        }
    },
    components: {
        ShowQuestion
    },
    methods: {
        CheckAnswers() {
            var numberOfQuestions = this.currentQuiz.questions.length;
            var numberOfSelectedAnswers = this.$store.state.selectedAnswers.length;
            if (numberOfQuestions != numberOfSelectedAnswers) 
            {
                alert("Musisz zaznaczyć wszystkie odpowiedzi!");
            }
        }
    },
    watch: {
        currentQuiz(value) {
            if (value == null || (value.title == "" || value.title.Length == 0))
            {
                this.msg = "ERROR"; 
            }
            else 
            {
                this.isPageReady = !this.isPageReady;
            }
        },
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
            this.$store.commit('clearAnswers');
        }
    }
}
</script>