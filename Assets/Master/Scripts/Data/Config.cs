using System.Collections.Generic;
using UnityEngine;

public class Config 
{
    // Path
    public static string StreamingAssetsPath => Application.streamingAssetsPath;
    public const string ElementsData = "ElementsData.json";
    public const string FullElementDetails = "FullElementDetails.json";


    // Text Button
    public const string Button_Yes = "Đồng ý";
    public const string Button_No = "Không";


    // State Of Matter
    public const string Solid = "Rắn";
    public const string Liquid = "Lỏng";
    public const string Gas = "Khí";

    public static string DefaultState_Solid => ElementsByState["Rắn"][0];
    public static string DefaultState_Liquid => ElementsByState["Lỏng"][0];
    public static string DefaultState_Gas => ElementsByState["Khí"][0];

    public static Dictionary<string, List<string>> ElementsByState = new Dictionary<string, List<string>>()
    {
        { "Rắn", new List<string>
        {
            "Sulfur", "Phosphorus", "Iodine", "Carbon", "Silicon", "Copper", "Calcium", "Aluminium",
            "Silver", "Magnesium", "Iron", "Zinc", "Sodium", "Gold", "Lead", "Barium", "Potassium",
            "Manganese", "Beryllium"
        }
        },
        { "Lỏng", new List<string>
        {
            "Bromine", "Mercury"
        }
        },
        { "Khí", new List<string>
        {
            "Chlorine", "Oxygen", "Nitrogen", "Helium", "Neon", "Argon", "Fluorine", "Hydrogen"
        }
        }
        };
    }
