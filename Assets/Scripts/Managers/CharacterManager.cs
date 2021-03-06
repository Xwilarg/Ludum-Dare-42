﻿using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characPrefab;
    [SerializeField]
    private GameObject descriptionPanel;
    [SerializeField]
    private Text nameText, description1;
    [SerializeField]
    private Image image;
    private PlayerController pc;

    private readonly Vector2 refTimer = new Vector2(3f, 5f);
    private float timer;

    private void Start()
    {
        timer = Random.Range(refTimer.x, refTimer.y);
        Character.Reset();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = Random.Range(refTimer.x, refTimer.y);
            GameObject go = Instantiate(characPrefab, new Vector2(15f, Random.Range(3f, 4f)), Quaternion.identity);
            MyCharacter charac = go.GetComponent<MyCharacter>();
            if (Character.basicCharacters.Count > 0 && Random.Range(0, 6) == 0)
            {
                if (Random.Range(0, 2) == 0 || pc.perso != PlayerController.Perso.Leandre || !Character.basicCharacters.Any(x => x.sexe == Character.Sexe.Female))
                    charac.me = Character.basicCharacters[Random.Range(0, Character.basicCharacters.Count)];
                else
                {
                    Character[] girls = Character.basicCharacters.Where(x => x.sexe == Character.Sexe.Female).ToArray();
                    charac.me = girls[Random.Range(0, girls.Length)];
                }
            }
            else
            {
                charac.me = Character.clone;
                charac.me.weapon = Weapon.Weapons[Random.Range(0, Weapon.Weapons.Length)];
            }
            Character.basicCharacters.Remove(charac.me);
            go.GetComponent<Animator>().runtimeAnimatorController = charac.me.hanging;
            charac.SetDescriptionPanel(descriptionPanel, nameText, description1, image);
        }
    }
}
