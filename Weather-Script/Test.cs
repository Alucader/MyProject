using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weather;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    List<string> city = new List<string>();
    List<string> province = new List<string>();
    public string cityName;
    public string[] strPr;
    public string[] str;
    public Text text;
    public  InputField inputCity;
    public Dropdown cityDp;
    public Dropdown provinceDp;
    public string[] str1 ;
    Text textP;
    Text textC;
    public string id;
    [Space]
    public Image icon;
    public Text textweather;
    public Text textray;
    public Text textfeng;
    public Text timeText;
    private bool isSearch=false ;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
       // icon = GameObject .Find("weather").GetComponent<Image>();
        textP = provinceDp.GetComponentInChildren<Text>();
        textC = cityDp.GetComponentInChildren<Text>();
        try
        {
            Weather.WeatherWebService ww = new WeatherWebService();
            strPr = ww.getSupportProvince();
            foreach (string item in strPr)
            {
                province.Add(item);
            }
            provinceDp.AddOptions(province);
            isSearch = true;
        }
        catch (System.Exception ex)
        {
            text.text = ex.Message;
        }

    }

    // Update is called once per frame
    void Update()
    {
      if(isSearch == false)
        {
            try
            {
                Weather.WeatherWebService ww = new WeatherWebService();
                strPr = ww.getSupportProvince();
                foreach (string item in strPr)
                {
                    province.Add(item);
                }
                provinceDp.AddOptions(province);
                isSearch = true;
                text.text = "";
            }
            catch (System.Exception ex)
            {
                text.text = ex.Message;
                return;
            }
        }

    }

    IEnumerator WeatherSear()
    {
        try
        {
            Weather.WeatherWebService ww = new WeatherWebService();
            str = ww.getWeatherbyCityName(cityName);
            text.text = str[0] + " " + str[1] + "\r\n" + "\r\n" + str[10];
            textweather.text = str[6] + str[5];
            textray.text = str[11];
            textfeng.text = str[7];
            timeText.text = str[4];
            string[] icons = str[8].Split('.');
            Sprite sp = Resources.Load(icons[0], typeof(Sprite)) as Sprite;
            icon.sprite = sp;
        }
        catch (System.Exception ex)
        {
            text.text = ex.Message;
        }
        // text.text = cityName;
        yield return 0;
    }
    IEnumerator CitySear()
    {
        try
        {
            str1 = null;
            city.Clear();
            cityDp.ClearOptions();

            Weather.WeatherWebService ww = new WeatherWebService();
            str1 = ww.getSupportCity(provinceDp.GetComponentInChildren<Text>().text);
            city.Add("请选择城市");
            foreach (string item in str1)
            {
                city.Add(item);
            }
            cityDp.AddOptions(city);
        }
        catch(System .Exception ex)
        {
            text.text = ex.Message;
        }
        yield return 0;
    }

    public void ProvinceChanged()
    {
        Debug.Log(textP.text);
        if (textP.text == "请选择省份")
            return;
        StartCoroutine(CitySear());
    }

    public void CityChanged()
    {
        Debug.Log(textC.text);
        
        if (textC.text == "请选择城市")
            return;
        string[] split = textC.text.Split('(');
        cityName = split[0];
        Debug.Log(cityName);
        StartCoroutine(WeatherSear());
    }

    public void Close()
    {
        Debug.Log("退出");
        Application.Quit();
    }


}
