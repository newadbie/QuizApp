<template>
    <div>
        {{data.data[0].title}}
    </div>    
</template>

<script>
const API_URL = "https://localhost:5001/api/Quizzes";
const axios = require('axios');

export default {
    data: function() {
        return {
            data: ""
        }
    },
    mounted() {

        axios.get(API_URL)
        .then(response => this.data = response);
    }
}
</script>