// src/app/models/quiz-answer.model.ts
export interface QuizAnswer {
  id: number;       // Renamed id to answerId based on the response
  answerText: string;
  isCorrect: boolean;
}

// src/app/models/quiz-question.model.ts
export interface QuizQuestion {
  id: number;
  questionText: string;
  answers: QuizAnswer[];  // Array of QuizAnswer objects
}

// Since you're receiving an array of QuizQuestion directly, you can simply use this array type:
export type QuizResponse = QuizQuestion[];  // An array of QuizQuestion


export interface QueryParams {
  dataSource?: string; // Add more query parameters as needed
}
