Smlusing System;
namespace SML_Generator
{
    public  class SmlBuilderFactory
{
	public SmlBuilderFactory()
	{

	}

	public static SmlBuilder CreateSmlBuilder(string filePath)
        {
            return new SmlBuilder(filePath);
        }



    }
