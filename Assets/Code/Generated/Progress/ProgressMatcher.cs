//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ProgressMatcher {

    public static Entitas.IAllOfMatcher<ProgressEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<ProgressEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<ProgressEntity> AllOf(params Entitas.IMatcher<ProgressEntity>[] matchers) {
          return Entitas.Matcher<ProgressEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<ProgressEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<ProgressEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<ProgressEntity> AnyOf(params Entitas.IMatcher<ProgressEntity>[] matchers) {
          return Entitas.Matcher<ProgressEntity>.AnyOf(matchers);
    }
}