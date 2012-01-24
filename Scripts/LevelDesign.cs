using UnityEngine;
using System.Collections.Generic;
using System.IO;
public class LevelDesign : MonoBehaviour {
	
	private TextAsset text;
	private StringReader reader;
	private string line = "";
	private int linecount = 0;
	private List<Dictionary<string, int>> phaseNotes = new List<Dictionary<string, int>>();
	private float musicTick = 0;
	private int maxDuration = 0;
	// Use this for initialization
	void Start () {
		   
	}	
	protected List<Dictionary<string, int>> loadLevel(int level)
	{	
		if(reader == null){
			text = (TextAsset)Resources.Load("LevelDesign/fases/fase" + level,typeof(TextAsset));
			reader = new StringReader(text.text);
		}
		
		while((line = reader.ReadLine()) != null){
			if(line.Contains(",")){				
				string[] note = line.Split(new char[]{','});
				phaseNotes.Add(new Dictionary<string,int>(){
					{"time",int.Parse(note[0])},
					{"show",int.Parse(note[1])},
					{"note",int.Parse(note[2])}
				});				
				linecount++;			
			}else if(line.Contains("tick"))
			{
				string[] tick = line.Split(new char[]{':'});
				musicTick = float.Parse(tick[tick.Length - 1]);
				
				linecount ++;
			}
		}
		linecount = 0;
		
		return getNotesDuration(excludeDoubleNotes(phaseNotes));
		
	}
	private List<Dictionary<string, int>> getNotesDuration(List<Dictionary<string, int>> notes){
		for(int i =0; i < notes.Count; i++){
			if(notes[i]["show"] == 1){
				Dictionary<string,int> notepair = getPair(notes[i],i,notes);
				float duration = notepair["time"] - notes[i]["time"];
				
				notes[i].Add("duration", (int)duration);
				maxDuration = (int)duration;
			}
		}
		return notes;
	}
	private List< Dictionary<string, int>>  excludeDoubleNotes(List< Dictionary<string, int>> notes){
		for(int i = 0; i < notes.Count; i++){
			for(int cont = i+1; cont < notes.Count; cont++){
				if(notes[i]["time"] == notes[cont]["time"]){
					if(notes[i]["show"] == 1)
						if(notes[i]["note"] > notes[cont]["note"])
						{
							notes.Remove(getPair(notes[cont],cont,notes));
							notes.RemoveAt(cont);
						}
						else{	
							notes.Remove(getPair(notes[i],i,notes));
							notes.RemoveAt(i);
						}
				}
			}
		}
		return notes;
	}
	
	private Dictionary<string, int> getPair(Dictionary<string,int> note, int noteNumber, List<Dictionary<string , int>> notes){
		for(int i = noteNumber; i < notes.Count; i++){
			if(notes[i]["note"] == note["note"]){
				if(notes[i]["show"] == 0){
					return notes[i];
				}
			}
		}
		return null;
	}
	protected int getFirstNote(){
		return phaseNotes[0]["note"];
	}
	protected int getLastNote(){
		return phaseNotes[phaseNotes.Count -1]["note"];
	}
	protected float getNextNoteTime(int noteNumber){
		if(phaseNotes.Count > noteNumber)
			return phaseNotes[noteNumber]["time"];
		else 
			return 0;
	}
	protected int getMaxDuration(){
		return maxDuration;
	}
	protected float getMusicTick(){
		return musicTick;
	}
	protected Dictionary<string,int> getNextNote(Dictionary<int, Dictionary<string,int>>notes, int currentNote){
		
		return new Dictionary<string, int>(){
			{"time",notes[currentNote+1]["time"]},
			{"show",notes[currentNote+1]["show"]},
			{"note",notes[currentNote+1]["note"]}
		};
	}
	protected Dictionary<string, int> getMiddleNote(){
		int indexMiddleNote = (int)Mathf.Floor(phaseNotes.Count/2);		
		
		for(int i = indexMiddleNote; i < phaseNotes.Count; i++){
			Dictionary<string, int> middleNote = phaseNotes[i];	
			if(middleNote["show"] == 1){
				middleNote.Add("noteNumber",i);
				return middleNote;
			}
		}
		return null;
	}
	                                                 
}