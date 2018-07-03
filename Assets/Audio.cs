using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class Audio : MonoBehaviour, IInputClickHandler
{
    private TextToSpeech textToSpeech;
    public string speakText;
    private void Awake()
    {
        textToSpeech = GetComponent<TextToSpeech>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var msg = string.Format(speakText, textToSpeech.Voice.ToString());

        textToSpeech.StartSpeaking(msg);
    }
    /* // Use this for initialization
     void Start()
     {
         var soundManager = GameObject.Find("AudioManager");
         TextToSpeechManager textToSpeech = soundManager.GetComponent<TextToSpeechManager>; ();
         textToSpeech.Voice = TextToSpeechVoice.Mark;
         textToSpeech.SpeakText("Welcome to the Holographic App ! You can use Gaze, Gesture and Voice Command to interact with it!");
     }

     // Update is called once per frame
     void Update()
     {

     }
     */
}