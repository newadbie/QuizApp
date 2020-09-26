import { API_URL } from '@/Quiz/Config'
const axios = require('axios');


export let GetQuizzes = new Promise((resolve) => { 
    let Quizzes;
    axios.get(API_URL).then(res => Quizzes = res.data).finally(() => {
        resolve(Quizzes);
    });
}) ;
