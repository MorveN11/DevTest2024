import { Poll, Option } from '@/models/poll.model';

export type OptionAdapter = {
  id: string;
  name: string;
  votes: number;
};

export type PollAdapter = {
  id: string;
  name: string;
  options: OptionAdapter[];
};

export function toOption(adapter: OptionAdapter, totalVotes: number): Option {
  const percentage = adapter.votes === 0 || totalVotes === 0 ? 0 : ((adapter.votes / totalVotes) * 100).toFixed(2);

  return {
    id: adapter.id,
    name: adapter.name,
    votes: adapter.votes,
    votesPercentage: percentage
  };
}

export function toPoll(adapter: PollAdapter): Poll {
  const totalVotes = adapter.options.reduce((sum, option) => sum + option.votes, 0);

  return {
    id: adapter.id,
    name: adapter.name,
    totalVotes,
    options: adapter.options.map((o) => toOption(o, totalVotes))
  };
}
