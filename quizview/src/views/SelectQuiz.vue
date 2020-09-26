<template>
    <div>
        <h1>Select your quiz!</h1>
            <div class="container">
                <div class="option" v-for="quiz in state.Quizzes" :key="quiz.id">
                    <router-link :to="{ name: 'answerForQuiz', params: { id: quiz.id }}">
                        {{quiz.title}}
                    </router-link>
                </div>    
            </div>
    </div>
</template>

<script>
import { GetQuizzes } from '@/Quiz/GetQuizzes'
import { onBeforeMount, reactive} from 'vue'
export default {
    setup()
    {
        const state = reactive( {
            Quizzes: null
        })

        onBeforeMount(() => {
            GetQuizzes.then((data) => {
                state.Quizzes = data;
            });
        })

        return { state }
    }
}
</script>