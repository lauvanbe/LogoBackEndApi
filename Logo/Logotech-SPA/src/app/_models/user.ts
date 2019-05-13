import { Adresse } from './adresse';

export interface User {
  id: number;
  inami: number;
  nom: string;
  prenom: string;
  email: string;
  deplacement: string;
  adresse: Adresse;
  telFixe?: number;
  gsm?: number;
}
