using UnityEngine;
using System.Collections;

using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour {
    public string AdmobID_Banner;
    
	// Use this for initialization
	void Start () {
        BannerView banner = new BannerView(AdmobID_Banner, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);
        banner.Show();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
