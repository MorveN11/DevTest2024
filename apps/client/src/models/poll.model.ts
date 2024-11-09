export type Option = {
  id: string;
  name: string;
  votes: number;
  votesPercentage: string;
};

export type Poll = {
  id: string;
  name: string;
  totalVotes: number;
  options: Option[];
};
