using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class AssetWatcherWindow : EditorWindow {

    static public string externalFolderKey = "AssetWatcherExternalFolder";
    public string externalFolder;
    ModifiedFiles modifiedFiles;

    [MenuItem( "Window/Asset Watch Window" )]
    static void Init() {
        AssetWatcherWindow window = (AssetWatcherWindow)EditorWindow.GetWindow( typeof( AssetWatcherWindow ) );
    }

    void OnGUI() {
        externalFolder = EditorPrefs.GetString( externalFolderKey );

        GUILayout.Label( "Folder to Sync to" );
        string newExternalFolder = EditorGUILayout.TextField( externalFolder );
        EditorPrefs.SetString( externalFolderKey, newExternalFolder );

        GUILayout.Space( 20 );
        ModifiedFiles modifiedFiles = ModifiedFiles.GetModifiedFiles();
        if ( modifiedFiles.addedFiles == null || modifiedFiles.addedFiles.Count < 1 ) {
            GUILayout.BeginVertical();
            GUILayout.Label( "No added files" );
            GUILayout.EndVertical();
        } else {
            GUILayout.BeginVertical();

            for ( int i = 0; i < modifiedFiles.addedFiles.Count; ++i ) {
                FileMod modification = modifiedFiles.addedFiles[i];
                GUILayout.BeginHorizontal();
                GUILayout.Label( modification.sourcePath );
                if ( GUILayout.Button( "Discard" ) ) {
                    Debug.Log( "This is supposed to discard" );
                    modifiedFiles.addedFiles.RemoveAt( i );
                    AssetDatabase.SaveAssets();
                }
                GUILayout.EndHorizontal();
            }


            if ( GUILayout.Button( "Push Changes" ) ) {
                foreach ( FileMod modification in modifiedFiles.addedFiles ) {
                    if ( Directory.Exists( modification.sourcePath ) ) {
                        Directory.CreateDirectory( modification.destinationPath );
                    } else {
                        File.Copy( modification.sourcePath, modification.destinationPath, true );
                    }
                }
                modifiedFiles.addedFiles.Clear();
                AssetDatabase.SaveAssets();
            }
            GUILayout.EndVertical();
        }
        GUILayout.Space( 20 );
        if ( modifiedFiles.deletedFiles == null || modifiedFiles.deletedFiles.Count < 1 ) {
            GUILayout.BeginVertical();
            GUILayout.Label( "No deleted files" );
            GUILayout.EndVertical();
        } else {
            GUILayout.BeginVertical();

            foreach ( string deletedFile in modifiedFiles.deletedFiles ) {
                GUILayout.BeginHorizontal();
                GUILayout.Label( deletedFile );
                if ( GUILayout.Button( "Discard" ) ) {
                    Debug.Log( "This is supposed to discard" );
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Button( "Push Changes" );
            GUILayout.EndVertical();
        }
    }
}
