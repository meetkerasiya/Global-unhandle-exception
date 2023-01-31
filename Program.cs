class MyClass
{
    public static void Main(string[] arguments)
    {
        AppDomain currentDomain= AppDomain.CurrentDomain;
        currentDomain.UnhandledException += new UnhandledExceptionEventHandler(
            (object sender,UnhandledExceptionEventArgs args) =>
            {
                Exception e = (Exception)args.ExceptionObject;
                Console.WriteLine("Global Handler caught : "+e.Message);
                Console.WriteLine("RunTime terminating: {0}", args.IsTerminating);
            });

        try
        {
            throw new Exception("1");

        }
        catch (Exception e)
        {
            Console.WriteLine("Catch clause caught : {0} \n",e.Message);

        }
        throw new Exception("2");
    }
}