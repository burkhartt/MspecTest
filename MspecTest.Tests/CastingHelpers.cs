namespace MspecTest.Tests {
    public static class CastingHelpers {
        public static T CastAs<T>(this object @object) {
            return (T) @object;
        }
    }
}