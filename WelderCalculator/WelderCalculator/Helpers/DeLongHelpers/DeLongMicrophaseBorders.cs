namespace WelderCalculator.Helpers.DeLongHelpers
{
    public class DeLongMicrophaseBorders
    {
        public float yInAmBorder(float x)
        {
            return (-46f / 55f) * x - (1539f / 55f);
        }

        public float yIn0to2FBorder(float x)
        {
            return (104f / 75f) * x - (1813f / 150f);
        }

        public float yIn2t42FBorder(float x)
        {
            return (110f / 79f) * x - (1036f / 79f);
        }

        public float yIn4to6FBorder(float x)
        {
            return (110f / 79f) * x - (1102f / 79f);
        }

        public float yIn6to8FBorder(float x)
        {
            return (7f / 5f) * x - (149f / 10f);
        }

        public float yIn8to10FBorder(float x)
        {
            return (100f / 73f) * x - (1090f / 73f);
        }

        public float yIn10to12Border(float x)
        {
            return (4f / 3f) * x - (44f / 3f);
        }

        public float yIn12to14FBorder(float x)
        {
            return (99f / 76f) * x - (11111f / 760f);
        }

        public float yIn14to16FBorder(float x)
        {
            return (9f / 7f) * x - (522f / 35f);
        }

        public float yIn16to18FBorder(float x)
        {
            return (72f / 55f) * x - (888f / 55f);
        }

        public float yIn18PlusFBorder(float x)
        {
            return (84f / 67f) * x - (5176f / 335f);
        }
    }
}
