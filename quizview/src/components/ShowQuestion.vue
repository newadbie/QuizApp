<template>
    <div class="Question">
        <h2 class="QuestionTitle">{{Question.title}}</h2>
        <div class="Answers">
            <div class="Answer" v-for="answer in Question.answers"
             :key="answer.id">
                <input type="radio" :name="Question.id" :value="answer.id" :id="'answer' + answer.id"/>
                <label :for="'answer' + answer.id"> {{answer.title}} </label>
            </div>
        </div>
    </div>
</template>

<style lang="scss">
.Question 
{
    display:flex;
    flex-wrap:wrap;
    justify-content: center;
    flex-direction: column;
    .QuestionTitle{
        width:100%;
        display:block;
    }
    .Answers 
    {
        display:flex;
        width:50%;
        margin-left:25%;
        flex-direction: column;
        align-items:center;
        .Answer 
        {
            width:100%;
            display:flex;
            justify-content: center;
            align-items: center;
            padding:5px;

            ::first-letter {
                text-transform: uppercase;
            }

            label {
                width:70%;
                text-align:left;
            }

            input {
                margin: 0 10px 0 0;
                padding:0;
            }
        }
    }
}

</style>

<script>
export default {
    props: [ "Question" ]
}
</script>