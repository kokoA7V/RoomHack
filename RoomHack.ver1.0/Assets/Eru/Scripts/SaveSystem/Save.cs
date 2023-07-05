//�f�[�^���t�@�C���ɕۑ����܂�

using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Save : MonoBehaviour
{
    void OnEnable()
    {
        DoSave();
    }

    private void DoSave()
    {
#if UNITY_EDITOR
        //UnityEditor��Ȃ�
        //Asset�t�@�C���̒���Save�t�@�C���̃p�X������
        string path = Application.dataPath + "/Save";

#else
        //�����łȂ����
        //.exe������Ƃ����Save�t�@�C�����쐬�������̃p�X������
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";
        
#endif

        //�Z�[�u�t�@�C���̃p�X��ݒ�
        string SaveFilePath = path + "/save" + DataManager.saveFile + ".bytes";

        // �Z�[�u�f�[�^�̍쐬
        SaveData saveData = CreateSaveData();

        // �Z�[�u�f�[�^��JSON�`���̕�����ɕϊ�
        string jsonString = JsonUtility.ToJson(saveData);

        // �������byte�z��ɕϊ�
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

        // AES�Í���
        byte[] arrEncrypted = AesEncrypt(bytes);

        // �w�肵���p�X�Ƀt�@�C�����쐬
        FileStream file = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write);

        //�t�@�C���ɕۑ�����
        try
        {
            // �t�@�C���ɕۑ�
            file.Write(arrEncrypted, 0, arrEncrypted.Length);

        }
        finally
        {
            // �t�@�C�������
            if (file != null)
            {
                file.Close();
            }
        }
        this.enabled = false;//���̃X�N���v�g���I�t�ɂ���
    }

    // �Z�[�u�f�[�^�̍쐬
    private SaveData CreateSaveData()
    {
        //�Z�[�u�f�[�^�̃C���X�^���X��
        SaveData saveData = new SaveData();

        //�Q�[���f�[�^�̒l���Z�[�u�f�[�^�ɑ��
        saveData.testInt = GameData.testInt;
        saveData.testFloat = GameData.testFloat;
        saveData.testString = GameData.testString;
        saveData.testBool = GameData.testBool;

        return saveData;
    }


    /// AesManaged�}�l�[�W���[���擾

    private AesManaged GetAesManager()
    {
        //�C�ӂ̔��p�p��16����(Read.cs�Ɠ������)
        string aesIv = "0987654321098765";
        string aesKey = "1234567890123456";

        AesManaged aes = new AesManaged();
        aes.KeySize = 128;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(aesIv);
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }

    /// AES�Í���
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AES�}�l�[�W���[�̎擾
        AesManaged aes = GetAesManager();
        // �Í���
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

}