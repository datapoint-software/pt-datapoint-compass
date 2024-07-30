const h = document.getElementsByTagName("head")[0]!;

const ln = (as: string, href: string): Promise<HTMLLinkElement> => new Promise((resolve) => {
  const e = document.createElement("link");
  e.as = as;
  if (["font", "style"].includes(as)) e.crossOrigin = "anonymous";
  e.href = href;
  e.rel = "preload";

  e.onload = () => {
    if (as === "style") {
      const s = document.createElement("link");
      s.crossOrigin = e.crossOrigin;
      s.href = href;
      s.rel = "stylesheet";
      s.onload = () => resolve(s);
      h.append(s);
      return;
    }
    else
      resolve(e);
  };

  h.append(e);
});

export const pre = (resources: {
  fonts?: string[];
  images?: string[];
  styles?: string[];
}): Promise<HTMLLinkElement[]> => Promise.all([
  ...(resources.fonts ?? []).map(href => ln("font", href)),
  ...(resources.images ?? []).map(href => ln("image", href)),
  ...(resources.styles ?? []).map(href => ln("style", href))
]);
