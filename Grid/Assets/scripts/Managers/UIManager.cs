using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static Text _location;
    private static Image _backgroundImage;
    private static Image _playerPanelBackgroundImage;
    private static Image _npcPanelBackgroundImage;

	public static Text Location
    {
        get
        {
            return _location;
        }
        set
        {
            _location = value;
        }
    }

    public static Image BackgroundImage
    {
        get
        {
            return _backgroundImage;
        }
        set
        {
            _backgroundImage = value;
        }
    }

    public static Image PlayerPanelBackgroundImage
    {
        get
        {
            return _playerPanelBackgroundImage;
        }
        set
        {
            _playerPanelBackgroundImage = value;
        }
    }

    void Awake()
    {
        _location = GameObject.FindGameObjectWithTag(Tags.LOCATION_TEXT_UI).GetComponent<Text>();
        _backgroundImage = GameObject.FindGameObjectWithTag(Tags.BACKGROUND_IMAGE_UI).GetComponent<Image>();
        _playerPanelBackgroundImage = GameObject.FindGameObjectWithTag(Tags.PLAYER_PANEL_BACKGROUND_IMAGE_UI).GetComponent<Image>();
    }
}
