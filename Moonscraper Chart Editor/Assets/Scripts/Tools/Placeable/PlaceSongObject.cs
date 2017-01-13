﻿using UnityEngine;
using System.Collections;

public abstract class PlaceSongObject : ToolObject {
    protected SongObject songObject;
    protected SongObjectController controller;

    public override void ToolDisable()
    {
        editor.currentSelectedObject = null;
    }

    protected virtual void OnEnable()
    {
        Update();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        songObject.song = editor.currentSong;
        songObject.position = objectSnappedChartPos;
    }

    protected abstract void AddObject();

    public static void AddObjectToCurrentEditor(SongObject songObject, ChartEditor editor, bool update = true)
    {
        switch (songObject.classID)
        {
            case ((int)SongObject.ID.Note):
                PlaceNote.AddObjectToCurrentChart((Note)songObject, editor, update);
                break;
            case ((int)SongObject.ID.Starpower):
                PlaceStarpower.AddObjectToCurrentChart((StarPower)songObject, editor, update);
                break;
            case ((int)SongObject.ID.BPM):
                PlaceBPM.AddObjectToCurrentSong((BPM)songObject, editor, update);
                break;
            case ((int)SongObject.ID.Section):
                PlaceSection.AddObjectToCurrentSong((Section)songObject, editor, update);
                break;
            case ((int)SongObject.ID.TimeSignature):
                PlaceTimesignature.AddObjectToCurrentSong((TimeSignature)songObject, editor, update);
                break;
            default:
                break;
        }
    }

    protected void MovementControls()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AddObject();

            Destroy(gameObject);
        }
    }
}
