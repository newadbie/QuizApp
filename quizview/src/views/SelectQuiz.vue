<template>
    <div>
        <h1>Select your quiz!</h1>
            <div class="container">
                <div class="option" v-for="quiz in Quizzes" :key="quiz.id">
                    <router-link :to="{ name: 'answerForQuiz', params: { id: quiz.id }}">
                        {{quiz.title}}
                    </router-link>
                </div>    
            </div>
    </div>
</template>

<script>
const axios = require('axios').default;

export default {
    data() {
        return {
            Quizzes: null
        }
    },
    mounted() {
        axios.get("https://localhost:5001/api/Quizzes").then(response => {
            this.Quizzes = response.data;
        });
    }
}
</script>