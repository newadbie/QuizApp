<template>
    <div>
        <span v-for="quiz in Quizzes" :key="quiz.Id">
            {{quiz.id}}
            {{quiz.title}}
            <br />
        </span>      
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