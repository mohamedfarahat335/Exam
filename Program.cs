using System;
using System.Collections.Generic;

namespace Exam
{
    // Base Question Class
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> Answers { get; set; }
        public int RightAnswerId { get; set; }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = new List<Answer>();
        }

        public abstract void DisplayQuestion();
    }

    // Derived Question types
    public class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} (Mark: {Mark})");
            Console.WriteLine("1. True\n2. False");
        }
    }
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} (Mark: {Mark})");
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].AnswerText}");
            }
        }
    }

    // Answer class
    public class Answer
    {
        public int AnswerId_ans { get; set; }
        public string AnswerText_ans { get; set; }

        public Answer(int id, string text)
        {
            AnswerId_ans = id;
            AnswerText_ans = text;
        }
    }

    // Base Exam class
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        public abstract void ShowExam();
    }

    // Derived Final Class 
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }
        }
    }
    // Derived practical Exam
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
                Console.WriteLine($"Right Answer: {question.RightAnswerId}\n");
            }
        }
    }

    // Subject class
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public void CreateExam(Exam exam)
        {
            SubjectExam = exam;
        }

        public override string ToString()
        {
            return $"Subject: {SubjectName} (ID: {SubjectId})";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a subject
            Subject math = new Subject(1, "Mathematics");

            // Create an exam
            FinalExam finalExam = new FinalExam(90, 2);

            // Add questions (True or False)
            var q1 = new TrueOrFalseQuestion("Q1", "The earth is flat.", 5);
            q1.RightAnswerId = 2;
            finalExam.Questions.Add(q1);

            // Add questions (MCQ)
            var q2 = new MCQQuestion("Q2", "What is 2+2?", 10);
            q2.Answers.Add(new Answer(1, "3"));
            q2.Answers.Add(new Answer(2, "4"));
            q2.Answers.Add(new Answer(3, "5"));
            q2.RightAnswerId = 2;
            finalExam.Questions.Add(q2);

            // Assign exam to subject
            math.CreateExam(finalExam);

            // Display exam
            Console.WriteLine(math);
            math.SubjectExam.ShowExam();

        }
    }
}
