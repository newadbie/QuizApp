import { createStore } from 'vuex'

export default createStore({
  state: {
    selectedAnswers: []
  },
  getters: {
    selectedAnswer: state => state.selectedAnswer
  },
  mutations: {
    clearAnswers(state) {
      state.selectedAnswers = [];
    },
    selectAnswer(state, {lastSelectedAnswer, selectedAnswer})
    {
      if (lastSelectedAnswer != null)
      {
        state.selectedAnswers.splice(state.selectedAnswers.indexOf(lastSelectedAnswer), 1);
      }
      state.selectedAnswers.push(selectedAnswer);
    },
  },
  actions: {
  },
  modules: {
  }
})
