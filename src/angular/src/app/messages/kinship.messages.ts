import { Kinship } from "@app/app.enums";

export const KINSHIP_MESSAGES = new Map([
  [ Kinship.Aunt, $localize `:@@kinship-aunt:Aunt` ],
  [ Kinship.Child, $localize `:@@kinship-child:Child` ],
  [ Kinship.FirstCousin, $localize `:@@kinship-first-cousin:First Cousin` ],
  [ Kinship.Grandchild, $localize `:@@kinship-grandchild:Grandchild` ],
  [ Kinship.Grandparent, $localize `:@@kinship-grandparent:Grandparent` ],
  [ Kinship.GreatGrandchild, $localize `:@@kinship-great-grandchild:Great Grandchild` ],
  [ Kinship.GreatGrandparent, $localize `:@@kinship-great-grandparent:Great Grandparent` ],
  [ Kinship.HalfSibling, $localize `:@@kinship-half-sibling:Half Sibling` ],
  [ Kinship.Nephew, $localize `:@@kinship-nephew:Nephew` ],
  [ Kinship.Niece, $localize `:@@kinship-niece:Niece` ],
  [ Kinship.Parent, $localize `:@@kinship-parent:Parent` ],
  [ Kinship.SecondCousin, $localize `:@@kinship-second-cousin:Second Cousin` ],
  [ Kinship.Sibling, $localize `:@@kinship-sibling:Sibling` ],
  [ Kinship.Uncle, $localize `:@@kinship-uncle:Uncle` ]
]);
