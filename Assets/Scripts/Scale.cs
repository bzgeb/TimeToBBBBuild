public enum ScaleEnum
{
    Major,
    Minor,
    MelodicMinorAscending,
    MelodicMinorDescending,
    PentatonicMajor,
    Ionian,
    Aeolian,
    Dorian,
    Phrygian,
    Lydian,
    Mixolydian,
    Locrian
};

public static class Scale
{
    public static readonly int[] Major = { 2, 2, 1, 2, 2, 2, 1 };
    public static readonly int[] Minor = { 2, 1, 2, 2, 1, 2, 2 };
    public static readonly int[] MelodicMinorAscending = { 2, 1, 2, 2, 2, 2, 1 };
    public static readonly int[] MelodicMinorDescending = { 2, 1, 2, 2, 1, 2, 2 };
    public static readonly int[] PentatonicMajor = { 2, 2, 3, 2, 3 };
    public static readonly int[] Ionian = { 2, 2, 1, 2, 2, 2, 1 };
    public static readonly int[] Aeolian = { 2, 1, 2, 2, 1, 2, 2 };
    public static readonly int[] Dorian = { 2, 1, 2, 2, 2, 1, 2 };
    public static readonly int[] Phrygian = { 1, 2, 2, 2, 1, 2, 2 };
    public static readonly int[] Lydian = { 2, 2, 2, 1, 2, 2, 1 };
    public static readonly int[] Mixolydian = { 2, 2, 1, 2, 2, 1, 2 };
    public static readonly int[] Locrian = { 1, 2, 2, 1, 2, 2, 2 };

    public static ScaleEnum currentScale;
    public static int[] noteArray;
}
