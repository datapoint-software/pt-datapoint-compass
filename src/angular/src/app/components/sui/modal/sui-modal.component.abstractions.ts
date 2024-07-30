export type SuiModalComponentAction = {
  fn: () => void;
  label: string;
  type?: "primary" | "secondary" | "danger" | "light";
};
