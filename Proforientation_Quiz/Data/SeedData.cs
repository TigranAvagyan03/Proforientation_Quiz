namespace Proforientation_Quiz.Data
{
    using Microsoft.EntityFrameworkCore;
    using Proforientation_Quiz.Models;
    using System.Text.Json;

    namespace CareerTest.Data
    {
        public static class SeedData
        {
            public static async Task InitializeAsync(IServiceProvider serviceProvider)
            {
                using var context = new ApplicationDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

                if (context.Questions.Any()) return;

                var q1 = new Question
                {
                    Text = "Что вам интереснее делать в рабочее время?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Вести переговоры, убеждать", Traits = new TraitsVector { People = 7, Analytical = 1, Creative = 2, Practical = 0 } },
                new() { Text = "Изучать данные, искать закономерности", Traits = new TraitsVector { People = 0, Analytical = 7, Creative = 1, Practical = 2 } },
                new() { Text = "Придумывать идеи, концепции", Traits = new TraitsVector { People = 0, Analytical = 2, Creative = 7, Practical = 1 } },
                new() { Text = "Собирать, чинить, делать руками", Traits = new TraitsVector { People = 0, Analytical = 1, Creative = 1, Practical = 8 } }
            }
                };

                var q2 = new Question
                {
                    Text = "Как вы принимаете решения?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Советуюсь с людьми, учитываю эмоции", Traits = new TraitsVector { People = 7, Analytical = 1, Creative = 2, Practical = 0 } },
                new() { Text = "Анализирую факты и цифры", Traits = new TraitsVector { People = 0, Analytical = 8, Creative = 0, Practical = 2 } },
                new() { Text = "Доверяю интуиции и воображению", Traits = new TraitsVector { People = 0, Analytical = 2, Creative = 8, Practical = 0 } },
                new() { Text = "Проверяю на практике, тестирую", Traits = new TraitsVector{ People = 0, Analytical = 0, Creative = 2, Practical = 8 } }
            }
                };

                var q3 = new Question
                {
                    Text = "Что вас привлекает в работе?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Общение, помощь людям, поддержка", Traits = new TraitsVector { People = 8, Analytical = 1, Creative = 1, Practical = 0 } },
                new() { Text = "Поиск закономерностей, структура", Traits = new TraitsVector { People = 0, Analytical = 8, Creative = 1, Practical = 1 } },
                new() { Text = "Самовыражение, создание нового", Traits = new TraitsVector{ People = 0, Analytical = 1, Creative = 8, Practical = 1 } },
                new() { Text = "Конкретика, видимый результат", Traits = new TraitsVector { People = 0, Analytical = 0, Creative = 1, Practical = 9 } }
            }
                };

                var q4 = new Question
                {
                    Text = "Какой стиль работы вам ближе?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Постоянное общение с людьми", Traits = new TraitsVector { People = 5, Analytical = 0, Creative = 3, Practical = 1 } },
                new() { Text = "Работа с документами и отчётами", Traits = new TraitsVector{ People = 0, Analytical = 7, Creative = 0, Practical = 3 } },
                new() { Text = "Поиск новых идей", Traits = new TraitsVector{ People = 0, Analytical = 0, Creative = 8, Practical = 2 } },
                new() { Text = "Конкретные задачи и инструменты", Traits = new TraitsVector { People = 0, Analytical = 2, Creative = 1, Practical = 7 } }
            }
                };

                var q5 = new Question
                {
                    Text = "Что вас мотивирует?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Благодарность и отзывы людей", Traits = new TraitsVector { People = 8, Analytical = 1, Creative = 0, Practical = 1 } },
                new() { Text = "Осознание, что разобрались в сложном", Traits = new TraitsVector { People = 0, Analytical = 8, Creative = 0, Practical = 2 } },
                new() { Text = "Создание нового и красивого", Traits = new TraitsVector{ People = 0, Analytical = 0, Creative = 8, Practical = 2 } },
                new() { Text = "Видимая польза от ваших рук", Traits = new TraitsVector { People = 0, Analytical = 0, Creative = 2, Practical = 8 } }
            }
                };

                var q6 = new Question
                {
                    Text = "Как вы решаете проблему?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Обсуждаю с коллегами", Traits = new TraitsVector{ People = 7, Analytical = 1, Creative = 1, Practical = 1 } },
                new() { Text = "Делю на части и анализирую", Traits = new TraitsVector { People = 0, Analytical = 7, Creative = 1, Practical = 2 } },
                new() { Text = "Придумываю нестандартный ход", Traits = new TraitsVector{ People = 0, Analytical = 1, Creative = 8, Practical = 1 } },
                new() { Text = "Пробую, ошибаюсь, исправляю", Traits = new TraitsVector{ People = 0, Analytical = 1, Creative = 0, Practical = 9 } }
            }
                };

                var q7 = new Question
                {
                    Text = "Что вы цените в коллегах?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Умение слушать и поддерживать", Traits = new TraitsVector { People = 8, Analytical = 0, Creative = 0, Practical = 2 } },
                new() { Text = "Логику и чёткость мышления", Traits = new TraitsVector{ People = 0, Analytical = 8, Creative = 0, Practical = 2 } },
                new() { Text = "Креативность, лёгкость на подъём", Traits = new TraitsVector{ People = 0, Analytical = 0, Creative = 8, Practical = 2 } },
                new() { Text = "Ответственность и исполнительность", Traits = new TraitsVector { People = 0, Analytical = 0, Creative = 2, Practical = 8 } }
            }
                };

                var q8 = new Question
                {
                    Text = "Чем бы вы хотели заниматься через 10 лет?",
                    Options = new List<AnswerOption>
            {
                new() { Text = "Руководить командой, развивать людей", Traits = new TraitsVector { People = 7, Analytical = 1, Creative = 1, Practical = 1 } },
                new() { Text = "Глубоко исследовать сложную тему", Traits = new TraitsVector { People = 0, Analytical = 7, Creative = 1, Practical = 2 } },
                new() { Text = "Создавать что-то уникальное", Traits = new TraitsVector { People = 0, Analytical = 1, Creative = 7, Practical = 2 } },
                new() { Text = "Быть мастером своего дела", Traits = new TraitsVector { People = 0, Analytical = 1, Creative = 2, Practical = 7} }
            }
                };

                context.Questions.AddRange(q1, q2, q3, q4, q5, q6, q7, q8);

                var professions = new List<Profession>
        {
            new()
            {
                Title = "HR-менеджер",
                Traits = new TraitsVector { People = 9, Analytical = 3, Creative = 4, Practical = 1 },
                Description = "Работа с людьми, подбор персонала, корпоративная культура",
                RecommendationText = "Вам подходит работа с людьми. Развивайтесь в HR, психологии, коучинге."
            },
            new()
            {
                Title = "Аналитик данных",
                Traits = new TraitsVector{ People = 2, Analytical = 9, Creative = 3, Practical = 3 },
                Description = "Сбор, обработка и интерпретация данных",
                RecommendationText = "Вы любите работать с информацией. Попробуйте аналитику, BI, Data Science."
            },
            new()
            {
                Title = "UX/UI Дизайнер",
                Traits = new TraitsVector{ People = 4, Analytical = 3, Creative = 9, Practical = 2 },
                Description = "Визуальное оформление, UX/UI дизайн, создание концепций",
                RecommendationText = "У вас творческий склад ума. Идите в дизайн, архитектуру, искусство."
            },
            new()
            {
                Title = "Инженер-строитель",
                Traits = new TraitsVector { People = 1, Analytical = 4, Creative = 2, Practical = 9 },
                Description = "Строительство, проектирование, реализация объектов",
                RecommendationText = "Вы любите создавать и внедрять. Попробуйте инженерию, строительство."
            },
            new()
            {
                Title = "Маркетолог",
                Traits = new TraitsVector { People = 7, Analytical = 4, Creative = 6, Practical = 1 },
                Description = "Продвижение, реклама, стратегии",
                RecommendationText = "Вы умеете сочетать общение и творчество. Идите в маркетинг, PR, продажи."
            },
            new()
            {
                Title = "Программист",
                Traits = new TraitsVector{ People = 1, Analytical = 7, Creative = 2, Practical = 7 },
                Description = "Разработка ПО, архитектура решений",
                RecommendationText = "Вам подходит логика и практика. Становитесь разработчиком, системным архитектором."
            },
            new()
            {
                Title = "Психолог",
                Traits = new TraitsVector { People = 9, Analytical = 6, Creative = 2, Practical = 1 },
                Description = "Работа с людьми, диагностика, консультирование",
                RecommendationText = "Вы умеете слушать и анализировать. Идите в психологию, консультирование, коучинг."
            },
            new()
            {
                Title = "Архитектор",
                Traits = new TraitsVector { People = 2, Analytical = 4, Creative = 7, Practical = 7 },
                Description = "Проектирование зданий, пространств, эстетика и функциональность",
                RecommendationText = "Вы сочетаете творчество и практику. Попробуйте архитектуру, дизайн среды."
            }
        };

                context.Professions.AddRange(professions);
                await context.SaveChangesAsync();
            }
        }
    }
}
