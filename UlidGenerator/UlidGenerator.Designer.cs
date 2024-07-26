namespace UlidGenerator;
using System;

internal class UlidGenerator
{
    private static global::System.Resources.ResourceManager resourceMan;

    private static global::System.Globalization.CultureInfo resourceCulture;

    [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    internal UlidGenerator()
    {

    }

    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static global::System.Resources.ResourceManager ResourceManager
    {
        get
        {
            if (object.ReferenceEquals(resourceMan, null))
            {
                global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UlidGenerator.UlidGenerator", typeof(UlidGenerator).Assembly);
                resourceMan = temp;
            }

            return resourceMan;
        }

    }

    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static global::System.Globalization.CultureInfo Culture
    {
        get
        {
            return resourceCulture;
        }
        set
        {
            resourceCulture = value;
        }
    }

    /// <summary>
    ///   Looks up a localized string similar to A &quot;Hello World&quot; extension for DevToys.
    /// </summary>
    internal static string AccessibleName
    {
        get
        {
            return ResourceManager.GetString("AccessibleName", resourceCulture);
        }
    }

    /// <summary>
    ///   Looks up a localized string similar to A sample extension.
    /// </summary>
    internal static string Description
    {
        get
        {
            return ResourceManager.GetString("Description", resourceCulture);
        }
    }

    /// <summary>
    ///   Looks up a localized string similar to Hello World!.
    /// </summary>
    internal static string HelloWorldLabel
    {
        get
        {
            return ResourceManager.GetString("HelloWorldLabel", resourceCulture);
        }
    }

    /// <summary>
    ///   Looks up a localized string similar to My Awesome Extension.
    /// </summary>
    internal static string LongDisplayTitle
    {
        get
        {
            return ResourceManager.GetString("LongDisplayTitle", resourceCulture);
        }
    }

    /// <summary>
    ///   Looks up a localized string similar to My Extension.
    /// </summary>
    internal static string ShortDisplayTitle
    {
        get
        {
            return ResourceManager.GetString("ShortDisplayTitle", resourceCulture);
        }
    }

}