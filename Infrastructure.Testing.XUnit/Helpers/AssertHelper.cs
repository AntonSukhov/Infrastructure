using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Infrastructure.Testing.XUnit.Helpers
{
    /// <summary>
    /// Помощник для упрощения проверок в тестах.
    /// </summary>
    public static class AssertHelper
    {
        /// <summary>
        /// Проверяет, что указанное действие не выбрасывает никаких исключений.
        /// Если исключение выбрасывается, тест завершается с ошибкой.
        /// </summary>
        /// <param name="action">Действие, которое нужно выполнить и проверить на отсутствие исключений.</param>
        /// <param name="message">Необязательное сообщение, которое будет отображено, если тест завершится с ошибкой.</param>
        public static void DoesNotThrow(Action action, string? message = null)
        {
            ArgumentNullException.ThrowIfNull(action, nameof(action));

            var exception = Record.Exception(action);

            if (exception != null)
            {
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Проверяет, что указанное действие не выбрасывает исключение определенного типа.
        /// Если выбрасывается исключение указанного типа, тест завершается с ошибкой.
        /// </summary>
        /// <typeparam name="T">Тип исключения, которое не должно быть выброшено.</typeparam>
        /// <param name="action">Действие, которое нужно выполнить и проверить на отсутствие исключения типа T.</param>
        /// <param name="message">Необязательное сообщение, которое будет отображено, если тест завершится с ошибкой.</param>
        public static void DoesNotThrow<T>(Action action, string? message = null) where T : Exception
        {
            ArgumentNullException.ThrowIfNull(action, nameof(action));

            var exception = Record.Exception(action);

            if (exception is T)
            {
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Проверяет, что указанное действие выбрасывает исключение, которое является одним из двух указанных типов.
        /// Если исключение не выбрасывается или имеет другой тип, тест завершается с ошибкой.
        /// </summary>
        /// <typeparam name="T1">Первый тип исключения, который может быть выброшен.</typeparam>
        /// <typeparam name="T2">Второй тип исключения, который может быть выброшен.</typeparam>
        /// <param name="action">Действие, которое нужно выполнить и проверить на выброс исключения одного из типов T1 или T2.</param>
        /// <param name="message">Необязательное сообщение, которое будет отображено, если тест завершится с ошибкой.</param>
        public static void ThrowsOneOf<T1, T2>(Action action, string? message = null)
            where T1 : Exception
            where T2 : Exception
        {
            ArgumentNullException.ThrowIfNull(action, nameof(action));

            var exception = Assert.ThrowsAny<Exception>(action);

            if (!(exception is T1 || exception is T2))
            {
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Проверяет, что коллекция не null и содержит те же элементы, что и ожидаемая (с учётом компаратора).
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции.</typeparam>
        /// <param name="actual">Фактическая коллекция.</param>
        /// <param name="expected">Ожидаемая коллекция.</param>
        /// <param name="comparer">Компаратор для сравнения элементов.</param>
        /// <param name="message">Сообщение при ошибке.</param>
        public static void CollectionEqual<T>(
            IEnumerable<T> actual,
            IEnumerable<T> expected,
            IEqualityComparer<T> comparer,
            string? message = null)
        {
            if (actual is null && expected is null)
                return;

            if (actual is null)
                Assert.Fail(message ?? $"Фактическая коллекция null, но ожидаемая не null.");
            
            if (expected is null)
                Assert.Fail(message ?? "Ожидаемая коллекция null, но фактическая не null.");

            if (!actual.SequenceEqual(expected, comparer))
                Assert.Fail(message ?? "Коллекции не равны.");
        }

    }
}
