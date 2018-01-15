using Windows.ApplicationModel.Resources;

namespace _5ECharacterCreator
{
    public static class StringResources
    {
        public static ResourceLoader SR;

        static StringResources()
        {
            SR = new ResourceLoader();
        }
    }
}