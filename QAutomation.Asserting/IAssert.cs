namespace QAutomation.Asserting
{
    using System;

    public interface IAssert
    {
        void AreEqual(object expected, object actual);
        void AreEqual(object expected, object actual, string message);
        void AreEqual<T>(T expected, T actual) where T : class;
        void AreEqual<T>(T expected, T actual, string message) where T : class;
        void AreNotEqual(object expected, object actual);
        void AreNotEqual(object expected, object actual, string message);
        void AreNotEqual<T>(T expected, T actual) where T : class;
        void AreNotEqual<T>(T expected, T actual, string message) where T : class;
        void IsFalse(bool condition);
        void IsFalse(bool condition, string message);
        void IsTrue(bool condition);
        void IsTrue(bool condition, string message);

        void IsNull(object value);
        void IsNull(object value, string message);
        void IsNotNull(object value);
        void IsNotNull(object value, string message);
        void Fail(string message);
        void IsInstanceOfType(object value, Type expectedType);
        void IsInstanceOfType(object value, Type expectedType, string message);
    }
}
