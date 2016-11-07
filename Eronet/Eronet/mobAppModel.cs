// ?imageType=ws_icon_tiny
// ?imageType=ws_screenshot_small
/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class mobAppModel
{

    private mobAppModelAppInfo[] appInfoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("appInfo")]
    public mobAppModelAppInfo[] appInfo
    {
        get
        {
            return this.appInfoField;
        }
        set
        {
            this.appInfoField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class mobAppModelAppInfo
{

    private int idField;

    private bool preporucenoField;

    private string bannerField;

    private string appHeadlineField;

    private string storeURLField;

    private string iconUrlField;

    private string appDescField;

    private string[] screenshotsField;

    private string categoryField;

    private decimal ratingPointsField;

    private string storePriceField;

    private string developerField;

    /// <remarks/>
    public int id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public bool preporuceno
    {
        get
        {
            return this.preporucenoField;
        }
        set
        {
            this.preporucenoField = value;
        }
    }

    /// <remarks/>
    public string banner
    {
        get
        {
            return this.bannerField;
        }
        set
        {
            this.bannerField = value;
        }
    }

    /// <remarks/>
    public string appHeadline
    {
        get
        {
            return this.appHeadlineField;
        }
        set
        {
            this.appHeadlineField = value;
        }
    }

    /// <remarks/>
    public string storeURL
    {
        get
        {
            return this.storeURLField;
        }
        set
        {
            this.storeURLField = value;
        }
    }

    /// <remarks/>
    public string iconUrl
    {
        get
        {
            return this.iconUrlField;
        }
        set
        {
            this.iconUrlField = value;
        }
    }

    /// <remarks/>
    public string appDesc
    {
        get
        {
            return this.appDescField;
        }
        set
        {
            this.appDescField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("screenshot", IsNullable = false)]
    public string[] screenshots
    {
        get
        {
            return this.screenshotsField;
        }
        set
        {
            this.screenshotsField = value;
        }
    }

    /// <remarks/>
    public string category
    {
        get
        {
            return this.categoryField;
        }
        set
        {
            this.categoryField = value;
        }
    }

    /// <remarks/>
    public decimal ratingPoints
    {
        get
        {
            return this.ratingPointsField;
        }
        set
        {
            this.ratingPointsField = value;
        }
    }

    /// <remarks/>
    public string storePrice
    {
        get
        {
            return this.storePriceField;
        }
        set
        {
            this.storePriceField = value;
        }
    }

    /// <remarks/>
    public string developer
    {
        get
        {
            return this.developerField;
        }
        set
        {
            this.developerField = value;
        }
    }
}

