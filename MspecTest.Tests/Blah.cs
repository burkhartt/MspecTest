namespace MspecTest.Tests {
    public static class Blah {
        public static T CastAs<T>(this object @object) {
            return (T) @object;
        }
    }
}